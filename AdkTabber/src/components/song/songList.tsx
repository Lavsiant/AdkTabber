import TableHead from '@material-ui/core/TableHead';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableFooter from '@material-ui/core/TableFooter';
import TablePagination from '@material-ui/core/TablePagination';
import TableRow from '@material-ui/core/TableRow';
import TablePaginationActions from '../../helpers/tabelsPaginationActions';
import React from 'react';
import ReactDOM from 'react-dom';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import queryString from 'query-string';
import { Link } from 'react-router-dom';
import { getAllSongs } from './songActions'
import { withStyles } from '@material-ui/core/styles';
import "isomorphic-fetch";
import Paper from '@material-ui/core/Paper';
import ISong, { DifficultyType } from '../../interfaces/song';
import { AppDispatch } from '../../helpers/appDispatch';

import SongFilter from './songFilters'
import { TabType } from '../../interfaces/tab';

interface Props {
    songs: ISong[]    
    getAllSongs(): any
}

interface State {
    filteredSongs: any[];
    page: number;
    rowsPerPage: number;
}


class SongList extends React.Component<Props, State>{
    constructor(props) {
        super(props);
        this.state = {
            filteredSongs: [],
            page: 0,
            rowsPerPage: 5
        };
    }

    componentDidMount() {
        this.props.getAllSongs().then(() =>
            this.setState({ filteredSongs: this.props.songs })
        );

    }

    handleChangePage = (event, page) => {
        this.setState({ page });
    };

    handleChangeRowsPerPage = event => {
        this.setState({ rowsPerPage: +event.target.value });
    };

    openDetails = (song: ISong) => {
        window.location.href = '/song/' + song.id
    }

    filterSongs = (filterOptions: any) => {
        let songs = this.props.songs;
        if (filterOptions.name)
            songs = songs.filter(x => x.name.toLowerCase().includes(filterOptions.name.toLowerCase()));
        if (filterOptions.band)
            songs = songs.filter(x => x.band.toLowerCase().includes(filterOptions.band.toLowerCase()));
        if (filterOptions.difficulty && filterOptions.difficulty !== DifficultyType.Any)
            songs = songs.filter(x => x.difficulty === filterOptions.difficulty);
        if (filterOptions.tabType && filterOptions.tabType !== TabType.Any)
            songs = songs.filter(x => x.tabs.some(t=>t.type === filterOptions.tabType));          

        this.setState({ filteredSongs: songs });
    }

    render() {
        const { rowsPerPage, page } = this.state;
        const emptyRows = rowsPerPage - Math.min(rowsPerPage, this.state.filteredSongs.length - page * rowsPerPage);

        return (
            <div className='table-wrapper'>
                <SongFilter filterSongs={this.filterSongs}></SongFilter>
                <Table className={'table'} >
                    <TableHead>
                        <TableRow>
                            <TableCell style={{ fontSize: 20 }}> Name</TableCell>
                            <TableCell style={{ fontSize: 20 }} > Band </TableCell>
                            <TableCell style={{ fontSize: 20 }} > Dificulty </TableCell>
                            <TableCell style={{ fontSize: 20 }} numeric> Tempo </TableCell>

                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {this.state.filteredSongs.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map(song => {
                            return (
                                <TableRow key={song.id} className="table-field" onClick={() => this.openDetails(song)} >
                                    <TableCell style={{ fontSize: 18 }} component="th" scope="row" >
                                        {song.name}
                                    </TableCell>
                                    <TableCell style={{ fontSize: 18 }} numeric>{song.band}</TableCell>                            
                                    <TableCell style={{ fontSize: 18 }} numeric>{DifficultyType[song.difficulty]}</TableCell>
                                    <TableCell style={{ fontSize: 18 }} numeric>{song.tempo}</TableCell>  
                                </TableRow>
                            );
                        })}
                        {emptyRows > 0 && (
                            <TableRow style={{ height: 48 * emptyRows }}>
                                <TableCell colSpan={6} />
                            </TableRow>
                        )}
                    </TableBody>
                    <TableFooter>
                        <TableRow>

                            <TablePagination
                                rowsPerPageOptions={[2, 5, 10, 25]}
                                colSpan={3}
                                count={this.props.songs.length}
                                rowsPerPage={rowsPerPage}
                                page={page}
                                SelectProps={{
                                    native: true,
                                }}
                                onChangePage={this.handleChangePage}
                                onChangeRowsPerPage={this.handleChangeRowsPerPage}
                                ActionsComponent={TablePaginationActions}
                            />
                        </TableRow>
                    </TableFooter>
                </Table>
            </div>
        )
    }
}

let mapProps = (state: any) => {
    return {
        songs: state.songReducer.songs,        
    }
}

const mapDispatch = (dispatch: AppDispatch) => bindActionCreators(
    {
        getAllSongs: getAllSongs.action
    },
    dispatch);



export default connect(mapProps, mapDispatch)(SongList)
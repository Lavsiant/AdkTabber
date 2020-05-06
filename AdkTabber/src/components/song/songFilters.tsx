import React from 'react';
import ReactDOM from 'react-dom';
import TextField from '@material-ui/core/TextField';
import AddIcon from '@material-ui/icons/Add';
import Fab from '@material-ui/core/Fab';
import MenuItem from '@material-ui/core/MenuItem';
import { DifficultyType } from '../../interfaces/song';
import { TabType } from '../../interfaces/tab';

interface Props {
    filterSongs(options: any): void
}

interface State {
    name: string;
    band: string;
    difficulty: DifficultyType;
    tabType: TabType;    
}

export default class SongFilter extends React.Component<Props, State> {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            band: '',
            tabType: TabType.Any,
            difficulty: DifficultyType.Any,
        };
    }

    componentDidMount = () => {
      
    }

    onNameChanged = e => {

        this.setState({ name: e.target.value });

        this.props.filterSongs(
            {
                name: e.target.value,
                band: this.state.band,
                difficulty: this.state.difficulty,
                tabType: this.state.tabType,               
            });
    }

    onBandChanged = e => {

        this.setState({ band: e.target.value });

        this.props.filterSongs(
            {
                name: this.state.name,
                band: e.target.value,
                difficulty: this.state.difficulty,
                tabType: this.state.tabType,                    

            });
    }

    onTabTypeChanged = e => {
        this.setState({ tabType: e.target.value });

        this.props.filterSongs(
            {
                name: this.state.name,
                band: this.state.band,
                difficulty: this.state.difficulty,
                tabType: this.state.tabType,                    

            });
    }

    onDifficultyChanged = e => {
        this.setState({ difficulty: e.target.value });

        this.props.filterSongs(
            {
                name: this.state.name,
                band: this.state.band,
                difficulty: this.state.difficulty,
                tabType: this.state.tabType,           
            });
    }

   

    createTabOpen = () => {
        window.location.href = "/song-create";
    }

    render() {

        return (
            <div className="filter-bar" style={{ width: '100%' }}>
                <div className="filter">
                    <TextField
                        className="filter-field"
                        label={'Name'}
                        margin="normal"
                        variant="outlined"
                        onChange={this.onNameChanged}
                    />
                </div>
                <div className="filter">
                    <TextField
                        label={'Band'}
                        defaultValue=""
                        className="filter-field"
                        margin="normal"
                        variant="outlined"
                        onChange={this.onBandChanged}
                    />
                </div>
                <div className="filter">
                    <TextField
                        select
                        label={'Dificulty'}
                        //className={styles.textField}
                        value={this.state.difficulty}
                        name='difficulty'
                        // SelectProps={{
                        //     MenuProps: styles
                        // }}
                        helperText='Choose dificulty'
                        margin="normal"
                        variant="outlined"
                        onChange={this.onDifficultyChanged}
                    >
                        <MenuItem value={DifficultyType.Any}> Any </MenuItem>
                        <MenuItem value={DifficultyType.Easy}> Easy </MenuItem>
                        <MenuItem value={DifficultyType.Medium}> Medium </MenuItem>
                        <MenuItem value={DifficultyType.Hard}> Hard </MenuItem>      
                    </TextField>

                </div>

                <div className="filter">
                    <TextField
                        select
                        label={'Type'}
                        //className={styles.textField}
                        value={this.state.difficulty}
                        name='tabType'
                        // SelectProps={{
                        //     MenuProps: styles
                        // }}
                        helperText='Choose tab type'
                        margin="normal"
                        variant="outlined"
                        onChange={this.onTabTypeChanged}
                    >
                        <MenuItem value={TabType.Any}> Any </MenuItem>
                        <MenuItem value={TabType.Guitar}> Guitar </MenuItem>
                        <MenuItem value={TabType.Drums}> Drums </MenuItem>
                        <MenuItem value={TabType.Piano}> Piano </MenuItem>      
                    </TextField>

                </div>
            
                <div className="filter" style={{ float: 'right', paddingTop: 16 }}>
                    <Fab size="large" color="primary" style={{ float: 'right' }} aria-label={"Add song"} onClick={this.createTabOpen}>
                        <AddIcon />
                    </Fab>
                </div> 

            </div>
        );
    }
}
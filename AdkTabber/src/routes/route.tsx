import * as React from 'react';
import { Route, Switch, Redirect } from 'react-router';



export default class Routing extends React.Component {

    render() {
        return (

            <Switch>

                {/* <Route path="/playlists" component={Playlists} />
                <Route path="/song/:id" render={(props) => <SongDetails id={props.match.params.id} {...props}/>} />
                 */}                

                <Route exact path="/" render={() => (<Redirect to="/home" />)} />
            </Switch>

        );
    }
};
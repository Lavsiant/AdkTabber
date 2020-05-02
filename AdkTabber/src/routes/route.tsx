import * as React from 'react';
import { Route, Switch, Redirect } from 'react-router';
import Login from '../components/auth/login';
import Register from '../components/auth/register';


export default class Routing extends React.Component {

    render() {
        return (

            <Switch>

                {/* <Route path="/playlists" component={Playlists} />
                <Route path="/song/:id" render={(props) => <SongDetails id={props.match.params.id} {...props}/>} />
                 */}                
                <Route path="/login" component={Login} />
                <Route path="/signup" component={Register} />
                <Route exact path="/" render={() => (<Redirect to="/home" />)} />
            </Switch>

        );
    }
};
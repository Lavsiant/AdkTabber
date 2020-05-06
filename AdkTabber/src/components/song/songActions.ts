import { songService } from './../../services/songService';

import actionCreatorFactory from 'typescript-fsa'
import { asyncFactory } from 'typescript-fsa-redux-thunk'
import AuthState from '../../interfaces/auth/authState';
import handleRequest from '../../helpers/requestHandler';
import { push } from 'connected-react-router';
import Response from '../../interfaces/response'
import ISong from '../../interfaces/song';


var factory = actionCreatorFactory();
var createAsync = asyncFactory<AuthState>(factory);

export const getAllSongs = createAsync<{}, ISong[]>(
  'getAllSongs',
  async (p: {}, d: any) => {
    return await handleRequest<ISong[], {} >(songService.getAllSongs,d,p);
  });

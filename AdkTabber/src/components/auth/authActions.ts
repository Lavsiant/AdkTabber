import { authService } from './../../services/authService';
import IUser from './../../interfaces/IUser';
import actionCreatorFactory from 'typescript-fsa'
import { asyncFactory } from 'typescript-fsa-redux-thunk'
import { RegisterUserModel } from '../../interfaces/auth/registerViewModel';
import { LoginModel } from '../../interfaces/auth/loginViewModel';
import AuthState from '../../interfaces/auth/authState';
import handleRequest from '../../helpers/requestHandler';
import { push } from 'connected-react-router';
import Response from '../../interfaces/response'


var factory = actionCreatorFactory();
var createAsync = asyncFactory<AuthState>(factory);

export const register = createAsync<RegisterUserModel, IUser>(
  'register',
  async (p: RegisterUserModel, d: any) => {
    const user = await handleRequest<IUser, RegisterUserModel>(authService.register,d,p);
    localStorage.setItem('user', JSON.stringify(user));
    d(push('/tabs'));
    return user;
  });

export const login = createAsync<LoginModel, IUser>(
  'login',
  async (p: LoginModel, d: any, ) => {
    const user = await handleRequest<IUser, LoginModel>(authService.login, d, p);
    localStorage.setItem('user', JSON.stringify(user));
    d(push('/home'));
    return user;
  });

export const logout = createAsync<void,void>(
  'logout',
  async (p: void, d: any) => {
     await authService.logout();
     localStorage.removeItem('user');
     d(push('/login'));
  }
)

export const getCurrentUser = createAsync<void,IUser>(
  'current',
  async (p: void, d: any) => {
    var result : Response<IUser> = await authService.getCurrentUser();
    localStorage.setItem('user', JSON.stringify(result.data));
    return result.data;

  }
)
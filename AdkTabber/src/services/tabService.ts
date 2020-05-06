import { config } from '../helpers/config';
import IUser from '../interfaces/IUser';
import Response from '../interfaces/response'
import { RegisterUserModel } from '../interfaces/auth/registerViewModel';
import { LoginModel } from '../interfaces/auth/loginViewModel';
import {ApiError} from '../helpers/apiError'
import ITab from '../interfaces/tab';

export async function getTab(id: number) : Promise<Response<ITab>> {
    const res = await fetch('/api/tab/get?id=' + id);
    if(!res.ok){              
        throw new Error('Internal error');
    }    
    return res.json();

}
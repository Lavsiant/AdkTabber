import { config } from '../helpers/config';
import IUser from '../interfaces/IUser';
import Response from '../interfaces/response'
import { RegisterUserModel } from '../interfaces/auth/registerViewModel';
import { LoginModel } from '../interfaces/auth/loginViewModel';
import {ApiError} from '../helpers/apiError'
import ITab from '../interfaces/tab';
import ISong from '../interfaces/song';

export const songService = {    
    getAllSongs,   
    getSong,   
};

export async function getSong(id: number) : Promise<Response<ISong>> {
    const res = await fetch('/api/song/get?id=' + id);
    if(!res.ok){              
        throw new Error('Internal error');
    }    
    return res.json();

}

export async function getAllSongs(id: number) : Promise<Response<ISong[]>> {
    const res = await fetch('/api/song/all');
    if(!res.ok){              
        throw new Error('Internal error');
    }    
    return res.json();

}
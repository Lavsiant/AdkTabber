import { config } from '../helpers/config';
import IUser from '../interfaces/IUser';
import Response from '../interfaces/response'
import { RegisterUserModel } from '../interfaces/auth/registerViewModel';
import { LoginModel } from '../interfaces/auth/loginViewModel';
import {ApiError} from '../helpers/apiError'


export const authService = {
    login,
    register,
    logout,
    getCurrentUser
};

async function login(model: LoginModel) : Promise<Response<IUser>> {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(model)
    };

    const res = await fetch('/api/auth/login', requestOptions);
    // if(!res.ok){     
    //     let x = await res.json();         
    //     throw new Error('Internal error');
    // }    
    return res.json();   
}

async function register(user: RegisterUserModel) : Promise<Response<IUser>>{
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify(user)
    }

    const res = await fetch('/api/auth/signup',requestOptions);

    if(!res.ok){
        throw new ApiError(res.status, await res.text());
    }
    return res.json();      
}

async function logout() : Promise<void>{
    const res = await fetch('/api/auth/signout');
    if(!res.ok){
        throw new Error('Internal error');
    }        
}

async function getCurrentUser() : Promise<Response<IUser>>{
    const res = await fetch('/api/auth/current');
    if(!res.ok){
        throw new Error('Internal error');
    }     
    return res.json();  
}


import Response from '../interfaces/response'
import { push } from 'connected-react-router'

export default async function handleRequest<TResult, TParams>(
    fetch: (params: TParams) =>
        Promise<Response<TResult>>, dispatch: any, requestParams: TParams)
    : Promise<TResult> {

    try {
        const response: any = await fetch(requestParams);
        return response.data;
    }
    catch(error){
        // error redirects
        switch (error.statusCode){
            case 402:
                break;
            default:
                break;
        }
        throw error;
    }   
}
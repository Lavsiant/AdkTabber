import IUser from "../IUser";

export default interface AuthState{
    user?: IUser;
    isLoading?: boolean;
    error: string;
}
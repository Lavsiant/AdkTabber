export default interface IUser {
    username: string;
    email: string;
    firstName?: string;
    lastName?: string;
    id?: number;
    password: string;
    role?: number;
}
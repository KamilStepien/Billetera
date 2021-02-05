export interface UserModule
{
    id:number;
    email:string;
    firstName:string;
    lastName:string;
    avatarLink:string;
    token:string;
}



export interface UserRegisterModel
{
    email:string;
    password:string;
    firstName:string;
    lastName:string;
}

export interface UserAuthenticateModel
{
    email:string;
    password:string;
}
export class UserModule
{
    id:number;
    email:string;
    firstName:string;
    lastName:string;
    avatarLink:string;
    token:string;
}



export class UserRegisterModel
{
    email:string;
    password:string;
    firstName:string;
    lastName:string;
}

export class UserAuthenticateModel
{
    email:string;
    password:string;
}
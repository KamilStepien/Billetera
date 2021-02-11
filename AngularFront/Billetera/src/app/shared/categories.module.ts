export class CategorieForTransactionModel
{
    id:number;
    name:string;
}

export class CategorieModel
{
    id:number;
    userId:number;
    name:string;
}

export interface CategorieAddModel
{
    name:string;
}

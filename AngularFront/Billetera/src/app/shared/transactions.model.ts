import { CategorieForTransactionModel } from "./categories.module";

export interface TransactionModel
{
    id:number,
    categorie: CategorieForTransactionModel,
    title:string,
    createDate:Date,
    amount:number,
    isExpanse:boolean
}
export interface TransactionDeleteModel
{
    id:number,
    userId:number
}
export interface TransactionAddEditModel
{
    id:number,
    categorieId:number,
    userId:number,
    title:string,
    createDate:Date,
    amount:number,
    isExpanse:boolean
}
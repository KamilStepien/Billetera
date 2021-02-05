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

export interface TransactionEditModel
{
    id:number,
    categorieId:number,
    title:string,
    createDate:Date,
    amount:number,
    isExpanse:boolean
}

export interface TransactionAddModel 
{
    categorieId:number,
    title:string,
    createDate:Date,
    amount:number,
    isExpanse:boolean
}
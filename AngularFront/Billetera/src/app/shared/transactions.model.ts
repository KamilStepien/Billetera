import { CategorieForTransactionModel } from "./categories.module";

export class TransactionModel
{
    id:number;
    categorie: CategorieForTransactionModel;
    title:string;
    createDate:Date;
    amount:number;
    isExpense:boolean;
}

export class TransactionChartData
{
    date:Date;
    amountIncome:number;
    amountExpense:number;
}


export class TransactionEditModel
{
    id:number;
    userId:number;
    categorieId:number;
    title:string;
    createDate:Date;
    amount:number;
    isExpense:string;
}

export class TransactionAddModel 
{
    categorieId:number;
    userId:number;
    title:string;
    createDate:Date;
    amount:number;
    isExpense:string;
}


export class TransactionSearchModel
{
    minMoney: number;
    maxMoney: number;
    categorieId: number;
}


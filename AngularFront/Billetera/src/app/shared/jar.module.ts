enum JarState {
    Reached,
    NotReached,
    inProgress
}

export interface JarModel {
    id: number,
    name: string,
    createDate: Date,
    endDate: Date,
    currentMoney:number
    aim: number,
    procentFill:number,
    state: JarState
}

export interface JarEditModel
{
    id: number,
    userId:number,
    name: string,
    endDate: Date,
    aim: number,
    state: JarState
}

export interface JarAddModel
{
    userId:number,
    name: string,
    endDate: Date,
    aim: number,
    state: JarState
}

export interface JarAddMoneyModel
{
    jarId:number,
    money:number
}

export interface JarEndModel
{
    id:number,
    userId:number
}
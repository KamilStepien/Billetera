enum JarState {
    Reached,
    NotReached,
    inProgress
}

export class JarModel {
    id: number;
    name: string;
    createDate: Date;
    endDate: Date;
    currentMoney:number;
    aim: number;
    procentFill:number;
    state: JarState;
}

export class JarEditModel
{
    id: number;
    userId:number;
    name: string;
    endDate: Date;
    aim: number;
    state: JarState;
}

export class JarAddModel
{
    userId:number;
    name: string;
    endDate: Date;
    aim: number;
    state: JarState;
}

export class JarAddMoneyModel
{
    jarId:number;
    money:number;
}

export class JarEndModel
{
    id:number;
    userId:number;
}
import ITab from "./tab";

export default interface ISong {
    id: number;
    name: string;    
    band: string;
    tempo: number;
    tabs: ITab[];
    difficulty : DifficultyType;
}

export enum DifficultyType{
    Easy,
    Medium,
    Hard,
    Any
}
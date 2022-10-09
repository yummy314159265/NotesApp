import { Note } from "./Note";

export interface Notebook {
    notebookId: string;
    fkUserId: string;
    name: string;
    noteCount: number;
    dateCreated: Date;
    dateModified: Date;
    notes: Note[];
}
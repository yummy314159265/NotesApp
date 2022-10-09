export interface Note {
    noteId: string;
    fkNotebookId: string;
    title: string;
    type: number;
    content: string;
    dateCreated: Date;
    dateModified: Date;
}
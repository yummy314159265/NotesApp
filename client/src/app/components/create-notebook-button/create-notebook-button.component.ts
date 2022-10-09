import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Notebook } from 'src/app/models/Notebook';
import { NotebooksService } from 'src/app/services/notebooks/notebooks.service';
import { MatDialog } from '@angular/material/dialog';
import { CreateNotebookDialogComponent } from '../create-notebook-dialog/create-notebook-dialog.component';

@Component({
  selector: 'app-create-notebook-button',
  templateUrl: './create-notebook-button.component.html',
  styleUrls: ['./create-notebook-button.component.css']
})
export class CreateNotebookButtonComponent implements OnInit {

  @Output() newNotebookEvent = new EventEmitter<Notebook>();

  constructor(
    public auth: AuthService,  
    public dialog: MatDialog,
    private NBS: NotebooksService
  ) { }

  ngOnInit(): void {
  }

  openCreateNotebookDialog(): void {
    const dialogRef = this.dialog.open(CreateNotebookDialogComponent, {
      width: '300px'
    });

    dialogRef.afterClosed().subscribe(result => {

      if (result.name === '') {
        return;
      }

      this.createNotebook(result.name);
    });
  }

  createNotebook(name: string): void {

    if (name.trim() === '') return;

    this.NBS.createNotebook(name.trim()).subscribe(newNotebook => {
      this.addNewNotebook(newNotebook);
    });
  }

  addNewNotebook(newNotebook: Notebook) {
    this.newNotebookEvent.emit(newNotebook);
  }

}

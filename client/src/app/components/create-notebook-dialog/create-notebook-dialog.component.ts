import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-notebook-dialog',
  templateUrl: './create-notebook-dialog.component.html',
  styleUrls: ['./create-notebook-dialog.component.css']
})
export class CreateNotebookDialogComponent implements OnInit {

  name = new FormControl('');

  constructor(
    public dialogRef: MatDialogRef<CreateNotebookDialogComponent>,
  ) { }

  ngOnInit(): void {
  }

}

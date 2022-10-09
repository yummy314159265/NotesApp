import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Notebook } from 'src/app/models/Notebook';
import { NotebooksService } from 'src/app/services/notebooks/notebooks.service';

@Component({
  selector: 'app-notebooks',
  templateUrl: './notebooks.component.html',
  styleUrls: ['./notebooks.component.css']
})
export class NotebooksComponent implements OnInit {

  notebooks: Notebook[] = [];

  constructor(
    public auth: AuthService,
    private NBS: NotebooksService
  ) { }

  ngOnInit(): void {
    this.auth.user$.subscribe(user => {
      if (user != null && user.sub != null) {
        this.getNotebooks(user.sub);
      }
    });
  }

  getNotebooks(id: string): void {
    this.NBS.getNotebooks(id).subscribe(nb => {
      this.notebooks = nb;
    });
  }

  addNotebook(notebook: Notebook): void {
    this.notebooks.unshift(notebook);
  }
}

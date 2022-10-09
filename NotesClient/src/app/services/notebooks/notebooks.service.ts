import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Notebook } from 'src/app/models/Notebook';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NotebooksService {

  constructor(private http: HttpClient) { }

  createNotebook(name: string): Observable<Notebook> {
    return this.http.post<Notebook>(environment.baseURL + '/create-notebook', { name });
  }

  getNotebooks(id: string): Observable<Notebook[]> {
    return this.http.post<Notebook[]>(environment.baseURL + '/get-user-notebooks', { id });
  }
}

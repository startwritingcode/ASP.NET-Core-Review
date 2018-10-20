import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TodoList } from '../models/TodoList';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  API_URL = 'http://localhost:5000/api';

  constructor(private httpClient: HttpClient) { }

  getTodoLists(): Observable<[TodoList]> {
    return this.httpClient.get<[TodoList]>(`${this.API_URL}/todolists`);
  }
}

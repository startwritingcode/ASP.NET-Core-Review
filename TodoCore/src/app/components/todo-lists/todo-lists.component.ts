import { ApiService } from './../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { TodoList } from 'src/app/models/TodoList';

@Component({
  selector: 'app-todo-lists',
  templateUrl: './todo-lists.component.html',
  styleUrls: ['./todo-lists.component.css']
})
export class TodoListsComponent implements OnInit {

  todoLists: [TodoList];
  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getTodoLists().subscribe(result => {
      this.todoLists = result;
    });
  }
}

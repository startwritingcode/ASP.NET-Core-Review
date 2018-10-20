import { TodoItemComponent } from './components/todo-item/todo-item.component';
import { TodoItemsComponent } from './components/todo-items/todo-items.component';
import { TodoListCreateComponent } from './components/todo-list-create/todo-list-create.component';
import { TodoListComponent } from './components/todo-list/todo-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {TodoListsComponent} from './components/todo-lists/todo-lists.component';
import { TodoItemCreateComponent } from './components/todo-item-create/todo-item-create.component';

const routes: Routes = [
    { path:  '', redirectTo:  'todo-lists', pathMatch:  'full' },
    {   
        path:  'todo-lists',
        component:  TodoListsComponent
    },
    {
        path: 'create-todo-list',
        component: TodoListCreateComponent
    },
    {
        path: 'todo-lists/:todoId',
        component: TodoListComponent
    },
    {
        path: 'todo-lists/:todoId/items',
        component: TodoItemsComponent
    },
    {
        path: 'todo-lists/:todoId/items/:itemId',
        component: TodoItemComponent
    },
    {
        path: 'todo-lists/:todoId/create-todo-item',
        component: TodoItemCreateComponent
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
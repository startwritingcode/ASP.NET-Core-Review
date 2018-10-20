import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TodoListsComponent } from './components/todo-lists/todo-lists.component';
import { TodoListComponent } from './components/todo-list/todo-list.component';
import { TodoListCreateComponent } from './components/todo-list-create/todo-list-create.component';
import { TodoItemsComponent } from './components/todo-items/todo-items.component';
import { TodoItemComponent } from './components/todo-item/todo-item.component';
import { TodoItemCreateComponent } from './components/todo-item-create/todo-item-create.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    TodoListsComponent,
    TodoListComponent,
    TodoListCreateComponent,
    TodoItemsComponent,
    TodoItemComponent,
    TodoItemCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { TodoItem } from './TodoItem';

export class TodoList {
    id: number;
    name: string;
    description: string;
    isComplete: boolean;
    items: [TodoItem];
}

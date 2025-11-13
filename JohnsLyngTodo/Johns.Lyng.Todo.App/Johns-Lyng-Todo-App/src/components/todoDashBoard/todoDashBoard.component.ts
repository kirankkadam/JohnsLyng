import { Component, OnInit } from "@angular/core";
import { TodoTaskService } from "../../services/TodoTask.service";
import { TaskList } from "../../interfaces/TaskList";
import { TaskListItem } from "../../interfaces/TaskListItem";

@Component({
    selector: 'todo-dashboard',
    templateUrl: './todoDashBoard.component.html',
    styleUrls: ['./todoDashBoard.component.css'],
    standalone: false
})

export class TodoDashBoardComponent implements OnInit {

  NewTaskList: TaskList = {
    id: 0,
    title: '',
    description: '',
    tasks: []
  }

  TodoLists: TaskList[] = [];
  NewTask: TaskListItem = { id: 0, title: '', description: '' };
  ShowNoListsMessage: boolean = false;


  constructor(private todoService: TodoTaskService) { }

  ngOnInit(): void {
    this.NewTaskList = {
      id: 0,
      title: '',
      description: '',
      tasks: []
    }

    this.getAllTheLists();
  }

  createNewList(): void {
    this.todoService.createNewTaskList(this.NewTaskList).subscribe({
      next: () => {
        this.NewTaskList = {
          id: 0,
          title: '',
          description: '',
          tasks: []
        };
        this.getAllTheLists();
      },
      error: (errorMessage) => console.log(errorMessage)
    });
  }


  addItem(newTaskItem: TaskListItem, taskList: TaskList): void {
    taskList.tasks.push(newTaskItem);
    this.todoService.createNewItem(taskList.id, newTaskItem).subscribe({
      next: () => {
        this.getAllTheLists();
      },
      error: (errorMessage) => console.log(errorMessage)
    });
  }

  deleteItem(id: number, taskListId: number): void {
    if (confirm("Are you sure you want to delete this item?")) {

    }
  }

  deleteList(taskListId: number): void {
    if (confirm("Are you sure you want to delete this task list?")) {
      this.todoService.deleteList(taskListId).subscribe({
        next: (allLists) => this.getAllTheLists(),
        error: (errorMessage) => console.log(errorMessage)
      });
    }
  }

  getAllTheLists(): void{
        this.todoService.getTodoTaskLists(1).subscribe({
          next: (allLists) => {
            this.TodoLists = allLists;
            this.ShowNoListsMessage = this.TodoLists === null || this.TodoLists === undefined || this.TodoLists.length === 0
          },
          error: (errorMessage) => console.log(errorMessage)
        });
  }
}

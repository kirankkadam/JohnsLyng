import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { TaskList } from '../interfaces/TaskList';
import { TaskListItem } from '../interfaces/TaskListItem';

@Injectable({
  providedIn: 'root'
})

export class TodoTaskService {
  private listApiUrl = 'https://localhost:44357/List/';
  private itemApiUrl = 'https://localhost:44357/Item/';

  ServiceClient: HttpClient;

  private refreshSource = new Subject<void>();
  refresh$ = this.refreshSource.asObservable();

  triggerRefresh() {
    this.refreshSource.next();
  }

  constructor(private http: HttpClient) {
    this.ServiceClient = http;
  }

  getTodoTaskLists(userId: number): Observable<TaskList[]> {
    return this.ServiceClient.get<TaskList[]>(`${this.listApiUrl}?id=${userId}`);
  }

  createNewTaskList(list: TaskList | undefined): Observable<TaskList[]> {
    return this.ServiceClient.post<TaskList[]>(`${this.listApiUrl}create`, list);
  }

  updateTaskList(list: TaskList): Observable<TaskList[]> {
    return this.ServiceClient.post<TaskList[]>(`${this.listApiUrl}/${list.id}`, list);
  }

  deleteList(id: number): Observable<TaskList[]> {
    return this.ServiceClient.delete<TaskList[]>(`${this.listApiUrl}?listId=${id}`);
  }

  createNewItem(listId: number, item: TaskListItem): Observable<TaskList> {
    return this.ServiceClient.post<TaskList>(`${this.itemApiUrl}create?listId=${listId}`, { item: item });
  }

  updateItem(listId: number, item: TaskListItem): Observable<TaskListItem> {
    return this.ServiceClient.put<TaskListItem>(`${this.itemApiUrl}/${listId}`, item);
  }

  deleteItem(listId: number, itemId: number): Observable<void> {
    return this.ServiceClient.delete<void>(`${this.itemApiUrl}/${listId}/items/${itemId}`);
  }
}

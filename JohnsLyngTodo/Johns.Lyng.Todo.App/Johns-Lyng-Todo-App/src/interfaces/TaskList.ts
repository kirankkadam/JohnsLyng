import { TaskListItem } from "./TaskListItem";


export interface TaskList {
  id: number;
  title: string;
  description: string;
  tasks: TaskListItem[];
}

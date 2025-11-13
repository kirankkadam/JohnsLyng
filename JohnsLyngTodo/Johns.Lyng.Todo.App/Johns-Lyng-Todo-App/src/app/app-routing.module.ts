import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TodoDashBoardComponent } from '../components/todoDashBoard/todoDashBoard.component';

const routes: Routes = [{
  path: '',
  component: TodoDashBoardComponent,
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}

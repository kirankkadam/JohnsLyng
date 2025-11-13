import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { TodoDashBoardComponent } from '../components/todoDashBoard/todoDashBoard.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({ declarations: [
        AppComponent,
        TodoDashBoardComponent
    ],
    exports: [
        TodoDashBoardComponent
    ],
  bootstrap: [AppComponent], imports: [
        BrowserModule,
        FormsModule,
        AppRoutingModule], providers: [provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }

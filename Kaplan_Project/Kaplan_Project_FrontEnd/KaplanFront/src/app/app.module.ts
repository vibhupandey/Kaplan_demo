import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LessonService } from 'src/services/lesson.service';
import { LessonComponent } from './Lesson/lesson/lesson.component';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material';
import {MatGridListModule} from '@angular/material/grid-list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 

@NgModule({
  declarations: [
    AppComponent,
    LessonComponent 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatCardModule,MatGridListModule,
    BrowserAnimationsModule 
  ],
  providers: [LessonService],
  bootstrap: [AppComponent]
})
export class AppModule { }

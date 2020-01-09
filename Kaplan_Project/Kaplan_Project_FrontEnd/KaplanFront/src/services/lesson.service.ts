import { Injectable, InjectionToken, Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';  
import { map } from 'rxjs/operators';
import { baseApiURL } from 'src/constants/config';
import { LessonModel } from 'src/app/Lesson/lesson/Lesson-model';

@Injectable({
  providedIn: 'root',
})

export class LessonService {
  baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = baseApiURL;
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  GetLessonDetais(): Observable<LessonModel> {
    return this.http.get<LessonModel>(this.baseUrl+"Trainning/TrainningDetails").pipe(map(res=>res)) ;
  }
} 

import { Component, OnInit } from '@angular/core';
import { LessonService } from 'src/services/lesson.service';
import { LessonModel } from './Lesson-model';
import { Time } from '@angular/common';
import {  trigger,  state,  style,  animate,  transition,  query,  stagger} from '@angular/animations';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.css'],
  animations: [
    trigger('listStagger', [
      transition('* <=> *', [
        query(
          ':enter',
          [
            style({ opacity: 0, transform: 'translateY(-15px)' }),
            stagger(
              '700ms',
              animate(
                '700ms ease-out',
                style({ opacity: 1, transform: 'translateY(0px)' })
              )
            )
          ],
          { optional: true }
        ),
        query(':leave', animate('100ms', style({ opacity: 0 })), {
          optional: true
        })
      ])
    ])
  ]
})
export class LessonComponent implements OnInit {
  private lessonDatamodel =[];

  constructor(private lessonService:LessonService) { }

  ngOnInit() {
     this.lessonService.GetLessonDetais().subscribe((data :any) =>
      {
        console.log(data);
        if(data && data.length>0){
            
          const groups = data.reduce((groups, game) => {
            const date = game.time.split('T')[0];
            if (!groups[date]) {
              groups[date] = [];
            }
            groups[date].push(game);
            return groups;
          }, {});
          
          // Edit: to add it in the array format instead
          const groupArrays = Object.keys(groups).map((date) => {
            return { date,
                     newsfeed: groups[date]
            };
          });
          console.log(groupArrays);
          this.lessonDatamodel=groupArrays;  
          
        }
    
      });
  }
  public addhours(date: Date)
  {
    var datetimeNow = new Date(date); 
    var hour= datetimeNow.getHours()+1 ;
    return new Date(datetimeNow.getFullYear(),datetimeNow.getMonth(),datetimeNow.getDay(),datetimeNow.getHours()+1,datetimeNow.getMinutes(),datetimeNow.getSeconds());
  }

}

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonComponent } from './lesson.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { of } from 'rxjs';
import { LessonService } from 'src/services/lesson.service';

class MockLessonService {
  GetLessonDetais() {
    /* Pass the expected response within of()*/
    return of([]);
  }
}


describe('LessonComponent', () => {
  let component: LessonComponent;
  let fixture: ComponentFixture<LessonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LessonComponent ],
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
        { provide: LessonService, useClass: MockLessonService }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

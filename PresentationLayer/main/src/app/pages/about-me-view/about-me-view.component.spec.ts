import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutMeViewComponent } from './about-me-view.component';

describe('AboutMeViewComponent', () => {
  let component: AboutMeViewComponent;
  let fixture: ComponentFixture<AboutMeViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutMeViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutMeViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

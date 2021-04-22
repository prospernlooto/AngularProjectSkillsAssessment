import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactMeViewComponent } from './contact-me-view.component';

describe('ContactMeViewComponent', () => {
  let component: ContactMeViewComponent;
  let fixture: ComponentFixture<ContactMeViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactMeViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactMeViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

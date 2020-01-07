import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // Input variables shares data btw components
  @Input() valuesFromHome: any;

  // Output variables shares events btw components
  @Output() cancelRegister = new EventEmitter();
  // -----------------------------
  model: any = {};

  // To use the service is necesary inyect the Service that we want to use.
  constructor(private authService: AuthService) {}

  ngOnInit() {}

  register() {
    this.authService.register(this.model).subscribe(() => {
      console.log('registration succesful');
    }, error => {
      console.log(error);
    });

  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('Cancelled');
  }
}

import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { PaymentService } from '../../services/payment';

@Component({
  selector: 'app-payment-form',
  templateUrl: './payment-form.html',
  styleUrl: './payment-form.css'
})
export class PaymentFormComponent {

  form = this.fb.group({
    fullName: ['', Validators.required],
    identification: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', Validators.required],
    debtAmount: [0, Validators.required],
    proposedPayment: [0, Validators.required],
    daysOverdue: [0, Validators.required],
  });

  constructor(private fb: FormBuilder, private service: PaymentService) {}

  submit() {
    if (this.form.valid) {
      this.service.create(this.form.value).subscribe({
        next: () => alert('Solicitud enviada'),
        error: err => alert(err.error)
      });
    }
  }
}

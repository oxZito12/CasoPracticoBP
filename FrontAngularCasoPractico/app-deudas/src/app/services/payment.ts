import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class PaymentService {

  private api = 'http://localhost:4200/api/paymentintent';

  constructor(private http: HttpClient) {}

  create(data: any) {
    return this.http.post(this.api, data);
  }

  getAll() {
    return this.http.get(this.api);
  }
}

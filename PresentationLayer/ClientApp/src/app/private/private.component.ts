import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-private',
  templateUrl: './private.component.html'
})

export class PrivateDataComponent implements OnInit {

   privateDatas: [];

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   
    this.http.get("https://localhost:44325/" + 'privatedata/data').subscribe((result: any) => {
      this.privateDatas = result
      this.router.navigate(['/private'])
      console.log(result)
    },
      (error) => {
        error
      }
    );
  }
  ngOnInit(){ }
}


class Privateata {
  data :string
}

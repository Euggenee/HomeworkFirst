import { Time } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-public',
  templateUrl: './public.component.html',
})
export class PublicDataComponent {
  publicDatas: [];
  leadTime:LeadTime;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   
    this.http.get("https://localhost:44325/" + 'publicdata/data').subscribe((result: any) => {
      this.publicDatas = result
      this.router.navigate(['/public'])
      console.log(result)
    },(error) => {error });

      this.http.get("https://localhost:44325/" + 'api/DataProviderProfiler/get-dataProviderProfiler').subscribe((result: any) => {
        this.leadTime = result
        console.log(result);
      },(error) => { error});
  }
  ngOnInit(){ }
}

 class LeadTime
    {
       linqMethodLeadTime:number
       rawSQLQueryLeadTime: number
    }

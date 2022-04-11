import {GenericApiContract} from "./generic-api-contract";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";

@Injectable()
export class GenericApiService implements GenericApiContract {
  constructor(public http: HttpClient) {
  }

  get<ReturnType>(resource: string, ...args: any): Observable<ReturnType> {
    return this.http.get<ReturnType>(resource);
  }
}


// let response = new LocationResponseModel();
// response.addresses = [{
//   completeAddress: '4600 Silver Hill Rd, Washington, DC 20233',
//   longitude: -76.92744,
//   latitude: 38.845985
// }]

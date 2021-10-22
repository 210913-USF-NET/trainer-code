import { Params } from "@angular/router";
import { ReplaySubject } from "rxjs";

//from angular's routed component tutorial
//we're creating a stub for activated route that will stand in for the actual activated route
export class ActivatedRouteStub {
    // Use a ReplaySubject to share previous values with subscribers
    // and pump new values into the `params` observable
    private subject = new ReplaySubject<Params>();

    constructor(initialParams?: Params) {
        this.setParams(initialParams);
    }

    /** The mock paramMap observable */
    readonly params = this.subject.asObservable();

    /** Set the paramMap observable's next value */
    setParams(params: Params = {}) {
        this.subject.next(params);
    }
}
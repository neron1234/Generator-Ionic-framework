import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { DataService } from './data.service';

describe('DataService service', () => {
  let httpTestingController: HttpTestingController;
  let service: DataService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ 
        HttpClientTestingModule
      ],
      providers: [ 
        DataService
      ]
    });
    service = TestBed.get(DataService);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('DataService service: should send a get request', () => {
    const testData: any = { test: 'Test' };
    service.get('/test', null).subscribe(result => {
      expect(result).toEqual(testData);
    });
    const req = httpTestingController.expectOne('/test');
    expect(req.request.method).toEqual('GET');
    req.flush(testData);
  });

  it('DataService service: should send a post request', () => {
    const testData: any = { test: 'Test' };
    service.post('/test', null, null).subscribe(result => {
      expect(result).toEqual(testData);
    });
    const req = httpTestingController.expectOne('/test');
    expect(req.request.method).toEqual('POST');
    req.flush(testData);
  });

  it('DataService service: should send a put request', () => {
    const testData: any = { test: 'Test' };
    service.put('/test', null, null).subscribe(result => {
      expect(result).toEqual(testData);
    });
    const req = httpTestingController.expectOne('/test');
    expect(req.request.method).toEqual('PUT');
    req.flush(testData);
  });

  it('DataService service: should send a delete request', () => {
    const testData: any = { test: 'Test' };
    service.delete('/test', null).subscribe(result => {
      expect(result).toEqual(testData);
    });
    const req = httpTestingController.expectOne('/test');
    expect(req.request.method).toEqual('DELETE');
    req.flush(testData);
  });
});
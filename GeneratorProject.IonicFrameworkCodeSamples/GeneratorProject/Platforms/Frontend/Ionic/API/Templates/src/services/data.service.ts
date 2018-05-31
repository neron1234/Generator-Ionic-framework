/**
 * You should add your licence here, here is an example :
 *
 * SonarQube, open source software quality management tool.
 * Copyright (C) 2008-2013 SonarSource
 * mailto:contact AT sonarsource DOT com
 *
 * SonarQube is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * SonarQube is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/catch';

/**
 * class: DataService.
 * That class is a generic class used
 * in all Angular services.
 * This service is injected in the generation
 * process from a static file.
 */
@Injectable()
export class DataService {
    constructor(public http: HttpClient) { }

    /**
     * method: get.
     * A generic HttpClient get method.
     * @param uri An URI for get method, add URL param
     *            directly from here or use `parameters`.
     * @param parameters URL parameters.
     * @returns Returns an `Observable<any>`.
     */
    get(uri: string, parameters: { [param: string]: string | string[] }) {
        return this.http.get(uri, {
            params: parameters
        })
        .catch(error => {
            return Observable.throw(error || 'Server error');
        });
    }

    /**
     * method: post.
     * A generic HttpClient post method.
     * @param uri An URI for post method, add URL param
     *            directly from here or use `parameters`.
     * @param body A JSON body is requested here.
     * @param parameters URL parameters.
     * @returns Returns an `Observable<any>`.
     */
    post(uri: string, body, parameters: { [param: string]: string | string[] }) {
        return this.http.post(uri, body, {
            params: parameters
        })
        .catch(error => {
            return Observable.throw(error || 'Server error');
        });
    }

    /**
     * method: put.
     * A generic HttpClient put method.
     * @param uri An URI for put method, add URL param
     *            directly from here or use `parameters`.
     * @param body A JSON body is requested here.
     * @param parameters URL parameters.
     * @returns Returns an `Observable<any>`.
     */
    put(uri: string, body, parameters: { [param: string]: string | string[] }) {
        return this.http.put(uri, body, {
            params: parameters
        })
        .catch(error => {
            return Observable.throw(error || 'Server error');
        });
    }

    /**
     * method: delete.
     * A generic HttpClient delete method.
     * @param uri An URI for delete method, add URL param
     *            directly from here or use `parameters`.
     * @param parameters URL parameters.
     * @returns Returns an `Observable<any>`.
     */
    delete(uri: string, parameters: { [param: string]: string | string[] }) {
        return this.http.delete(uri, {
            params: parameters
        })
        .catch(error => {
            return Observable.throw(error || 'Server error');
        });
    }
}

import { Pipe, PipeTransform } from '@angular/core';
import { Constants } from 'src/util/Constants';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'DateTimeFormat'
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value, Constants.DATE_TIME_FMT);
  }

}

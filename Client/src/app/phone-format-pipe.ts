import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phoneFormat',
  standalone: true // Pipe standalone, compatible con Angular 20
})
export class PhoneFormatPipe implements PipeTransform {
  transform(value: string | null): string | null {
    // Si el valor es nulo o vacío, devolverlo sin cambios
    if (!value) {
      return value;
    }

    // Separar el prefijo (+) y los dígitos
    const hasPlus = value.startsWith('+');
    const prefix = hasPlus ? '+' : '';
    const digits = hasPlus ? value.slice(1).replace(/[^\d]/g, '') : value.replace(/[^\d]/g, '');

    // Dividir los dígitos en grupos: primero de 3, luego de 4
    const groups: string[] = [];
    if (digits.length >= 3) {
      groups.push(digits.slice(0, 3)); // Primer grupo de 3 dígitos
      let remaining = digits.slice(3);
      for (let i = 0; i < remaining.length; i += 4) {
        groups.push(remaining.slice(i, i + 4)); // Grupos de 4 dígitos
      }
    } else {
      groups.push(digits); // Si hay menos de 3 dígitos, no dividir
    }

    // Unir el prefijo y los grupos con espacios
    return prefix + groups.join(' ');
  }
}
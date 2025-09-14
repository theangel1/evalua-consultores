import { PhoneFormatPipe } from "./phone-format-pipe";



describe('PhoneFormatPipe', () => {
  let pipe: PhoneFormatPipe;

  beforeEach(() => {
    pipe = new PhoneFormatPipe();
  });

  it('deberia formatear el numero +56992861178 a +569 9286 1178', () => {
    const input = '+56992861178';
    const expectedOutput = '+569 9286 1178';
    expect(pipe.transform(input)).toBe(expectedOutput);
  });

  // Casos de prueba adicionales para mayor cobertura
  it('deberia manejar el numero sin + (56992861178 a 569 9286 1178)', () => {
    const input = '56992861178';
    const expectedOutput = '569 9286 1178';
    expect(pipe.transform(input)).toBe(expectedOutput);
  });

  it('deberia manejar el numero sin caracteres no numericos (+569-9286-1178 to +569 9286 1178)', () => {
    const input = '+569-9286-1178';
    const expectedOutput = '+569 9286 1178';
    expect(pipe.transform(input)).toBe(expectedOutput);
  });

  it('deberia manejar un numero corto (+123 to +123)', () => {
    const input = '+123';
    const expectedOutput = '+123';
    expect(pipe.transform(input)).toBe(expectedOutput);
  });

  it('deberia retornar null para un input null', () => {
    const input = null;
    expect(pipe.transform(input)).toBeNull();
  });

  it('deberia retornar vacio para un input vacio', () => {
    const input = '';
    expect(pipe.transform(input)).toBe('');
  });
});
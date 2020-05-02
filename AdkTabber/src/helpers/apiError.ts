export class ApiError extends Error {
    statusCode: number
    constructor(statusCode = 100, ...params) {
      // Pass remaining arguments (including vendor specific ones) to parent constructor
      super(...params)
  
      // Maintains proper stack trace for where our error was thrown (only available on V8)
      if (Error.captureStackTrace) {
        Error.captureStackTrace(this, ApiError)
      }
  
      this.name = 'CustomError'
      // Custom debugging information
      this.statusCode = statusCode
    }
  }
  
//   try {
//     throw new CustomError('baz', 'bazMessage')
//   } catch(e) {
//     console.error(e.name)    //CustomError
//     console.error(e.foo)     //baz
//     console.error(e.message) //bazMessage
//     console.error(e.stack)   //stacktrace
//   }
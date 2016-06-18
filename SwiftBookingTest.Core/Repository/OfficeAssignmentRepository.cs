﻿using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Repository
{
    public class OfficeAssignmentRepository : Repository<OfficeAssignment>, IOfficeAssignmentRepository
    {
        public OfficeAssignmentRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the by instructor.
        /// </summary>
        /// <param name="instructorId">The instructor identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IQueryable<OfficeAssignment> GetByInstructor(int instructorId)
        {
            return DbSet.Where(x => x.InstructorID == instructorId);
        }
    }
}

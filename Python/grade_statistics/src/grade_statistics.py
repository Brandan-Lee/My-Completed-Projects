#In this exercise you will write a program for printing out grade statistics for a university course.

#The program asks the user for results from different students on the course. These include exam points and
#  numbers of exercises completed. The program then prints out statistics based on the results.

#Exam points are integers between 0 and 20. The number of exercises completed is an integer between 0 and 100.

#The program keeps asking for input until the user types in an empty line. You may assume all lines contain
#  valid input, which means that there are two integers on each line, or the line is empty.

#When the user types in an empty line, the program prints out statistics. They are formulated as follows:

#The exercises completed are converted into exercise points, so that completing at least 10% of the exercises
#  grants one point, 20% grants two points, and so forth. Completing all 100 exercises grants 10 exercise
#  points. The number of exercise points granted is an integer value, rounded down.

#The grade for the course is determined based on the following table:

#exam points + exercise points	grade
# 0–14	0 (i.e. fail)
# 15–17	1
# 18–20	2
# 21–23	3
# 24–27	4
# 28–30	5
# There is also an exam cutoff threshold. If a student received less than 10 points from the exam, they automatically fail the course, regardless of their total number of points.

#Floating point numbers should be printed out with one decimal precision.

#NB: this exercise doesn't ask you to write any specific functions, so you should not place any code within an
#  if __name__ == "__main__" block. If any functionality in your program is e.g. in the main function, you
#  should include the code calling this function normally, and not contain it in an if block like in the
#  exercises which specify certain functions.

#Hint: The user input in this program consists of lines with two integer values:

#You have to first split the input line in two and then convert the sections into integers with the int 
# function. Splitting the input can be achieved in the same way as in the exercise First, second and last
#  words, but there is a simpler way as well. The string method split will chop the input up nicely. You will
#  find more information by searching for python string split online.

#sample output
# Statistics:
# Points average: 14.5
# Pass percentage: 75.0
# Grade distribution:
#   5:
#   4:
#   3: *
#   2:
#   1: **
#   0: *

# Write your solution here
def convert_excercises_completed_to_points(exercise: int):
    return exercise // 10

def determine_grade_for_course(exam: int, exercise: int):
    total = exam + exercise
    if exam < 10 or total <= 14:
        return 0
    elif total <= 17:
        return 1
    elif total <= 20:
        return 2
    elif total <= 23:
        return 3
    elif total <= 27:
        return 4
    elif total <= 30:
        return 5
    else:
        return None

def points_average(exam_points: list, exercise_points: list):
    sum = 0
    for i in range(len(exam_points)):
        sum += exam_points[i] + exercise_points[i]
    return sum / len(exam_points)

def pass_percentage(exam_points: list, exercise_points: list):
    pass_count = 0
    for i in range(len(exam_points)):
        grade = determine_grade_for_course(exam_points[i], exercise_points[i])
        if grade > 0:
            pass_count += 1
    return (pass_count / len(exam_points)) * 100

def grade_distribution(exam_points: list, exercise_points: list):
    grades = []
    for i in range(len(exam_points)):
        grade = determine_grade_for_course(exam_points[i], exercise_points[i])
        grades.append(grade)
    
    print("Grade distribution:")
    grade = 5
    while grade >= 0:
        stars = "*" * grades.count(grade)
        print(f"  {grade}: {stars}")
        grade -= 1

def generate_stats(exam_points: list, exercise_points: list):
    print("Statistics: ")
    print(f"Points average: {points_average(exam_points, exercise_points):.1f}")
    print(f"Pass percentage: {pass_percentage(exam_points, exercise_points):.1f}")
    grade_distribution(exam_points, exercise_points)


def main():
    #create empty list for excercise points and exam points
    exam_points = []
    exercise_points = []
    #loop until user enters an empty line
    while True:
        user_input = input("Exam points and exercises completed: ")
        #end program if user enters an empty line
        if user_input == "":
            break
        #add exam points to list
        exam_points.append(int(user_input.split()[0]))
        #add excercises completed to list
        exercises_completed = int(user_input.split()[1])
        exercise_points.append(convert_excercises_completed_to_points(exercises_completed))

    generate_stats(exam_points, exercise_points)

main()

#example of output
# Exam points and exercises completed: 15 87
# Exam points and exercises completed: 10 55
# Exam points and exercises completed: 11 40
# Exam points and exercises completed: 4 17
# Exam points and exercises completed: 
# Statistics: 
# Points average: 14.5
# Pass percentage: 75.0
# Grade distribution:
#   5:
#   4:
#   3: *
#   2:
#   1: **
#   0: *